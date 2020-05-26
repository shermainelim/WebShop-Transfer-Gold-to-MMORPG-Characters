using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamFourA.Db;
using TeamFourA.Models;

namespace TeamFourA.Services
{
    public class ProductService
    {
        private readonly ShoppingContext _dbContext;

        public ProductService(ShoppingContext shoppingContext)
        {
            this._dbContext = shoppingContext;
        }

        public Product getProductById(string id)
        {
            Product newProduct = new Product();
            newProduct = _dbContext.Products.Where(x => x.Id == id)
                .FirstOrDefault();

            return newProduct;
        }

        //------------------------------- Take Product Data by session ----------------------

        public List<ProductDetails> getProductDetailsList(string productIdList)
        {
            List<ProductDetails> productDetailsList = new List<ProductDetails>();
            ProductDetails productDetails = new ProductDetails();

            // convert productidList string into string[]
            string[] proId = productIdList.Split(";");
            Array.Sort(proId);

            int count = 0;
            int pointer = 0;
            string temp = proId[0];

            foreach (string id in proId)
            {
                pointer = pointer + 1;
                if (temp == id)
                {
                    count = count + 1;
                }
                else
                {
                    if (temp != null)
                    {
                        productDetails = myProductData(temp, count);
                        productDetailsList.Add(productDetails);
                        count = 1;
                    }
                }
                if (pointer == proId.Length)
                {
                    productDetails = myProductData(id, count);
                    productDetailsList.Add(productDetails);
                    count = 1;
                }
                temp = id;
            }
            return productDetailsList;
        }
        public ProductDetails myProductData(string temp, int count)
        {
            List<ProductDetails> productDetailsList = new List<ProductDetails>();
            Product product = new Product();
            product = getProductById(temp);

            //trying by creating new model Productdetails
            ProductDetails pd = new ProductDetails();
            pd.product = product;
            pd.Quantity = count;



            return pd;
        }

        //------------------------------- Purchase -------------------------

        public void purchasedService(List<ProductDetails> proList, string username, string gameusername)
        {
            //(optional) call paymentgateway (return true)
            // if (PaymentGateway.Pay() == false)
            // throw new Exception
            using (IDbContextTransaction transact = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    // save the data to the database
                    addPurchaseDataToDb(proList, username, gameusername);
                    PaymentGateway payment = new PaymentGateway();
                    if (payment.Pay() == false)
                        throw new Exception("Payment failed.");

                    transact.Commit();
                }
                catch (Exception)
                {
                    transact.Rollback();
                }
            }
        }

        public void addPurchaseDataToDb(List<ProductDetails> proList, string username, string gameusername)
        {
            User user = new User();
            user = findUserIdbyUserName(username);



            //add transactin data to transaction db
            Transaction transaction = new Transaction()
            {
                Id = Guid.NewGuid().ToString(),
                UserId = user.OldId,
                UtcTimestamp = DateTime.UtcNow,
                TransactionDetail = new List<TransactionDetail>()

            };

            //add transactiondetail data to db
            foreach (ProductDetails pd in proList)
            {
                TransactionDetail transactionDetail = new TransactionDetail()
                {
                    Id = Guid.NewGuid().ToString(),
                    TransactionId = transaction.Id,
                    ProductId = pd.product.Id,
                    Quantity = pd.Quantity,
                    Value= pd.product.Value*pd.Quantity,
                    Amount= pd.product.Price *pd.Quantity
                };

                if(transactionDetail.Value > 0)
                {
                    transactionDetail.GameUsername = gameusername;
                } 

                //add activation code data to db
                for (int j = 0; j < transactionDetail.Quantity; j++)
                {
                    ActivationCode activationCode = new ActivationCode()
                    {
                        Id = Guid.NewGuid().ToString(),
                        TransactionDetailId = transactionDetail.Id
                    };
                    _dbContext.ActivationCodes.Add(activationCode);
                }
                _dbContext.TransactionDetails.Add(transactionDetail);

                transaction.TransactionDetail.Add(transactionDetail);
            }

            _dbContext.Transactions.Add(transaction);
            _dbContext.SaveChanges();

        }

        private User findUserIdbyUserName(string username)
        {

            User user = _dbContext.Users.Where(x => x.Username == username)
                .FirstOrDefault();

            return user;
        }
    }
}
