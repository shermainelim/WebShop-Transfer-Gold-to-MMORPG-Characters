function updateCart() {
    var item1Unit = 0;
    var money = 0;
    var monitem = 0;
    var price = 0;
    var name = ""

    var total = 0;
    var table = document.getElementById("myTable");
    for (var i = 1, row; row = table.rows[i]; i++) {
        var priceitem1 = 0;
        var qty = 0;
        var itemtotal = 0
        for (var j = 0, col; col = row.cells[j]; j++) {
            if (col.id == "priceitem1") {
                priceitem1 = col.innerHTML;
            } else if (col.id == "qty") {
                qty = col.childNodes[0].value;
            } else if (col.id == "monitem1") {
                itemtotal = priceitem1 * qty;
                col.innerHTML = "$" + itemtotal;
                total += itemtotal;
            }
        }
    }

    /*if (document.getElementById("rowNo")) {

        name = document.getElementById("nameitem1").innerHTML;
        price = document.getElementById("priceitem1").innerHTML;
        item1Unit = document.getElementById("qtyitem1").value;
        money = document.getElementById("monitem1").innerHTML

        console.log(name + " " + price + " " + item1Unit + " " +money )

        var amount1 = item1Unit * price;
    }


    if (document.getElementById("rowNo")) {
        document.getElementById("monitem1").innerHTML = "$" + amount1;
    }
    document.getElementById("monitem1").innerHTML = "$" + amount1;*/
    document.getElementById("subtotal").innerHTML = "$" + total;
    document.getElementById("total").innerHTML = "$" + total;


}

function remove_item(rowId) {
    console.log(rowId)
    document.getElementById("myTable").deleteRow(document.getElementById(rowId).rowIndex);
    updateCart();
}