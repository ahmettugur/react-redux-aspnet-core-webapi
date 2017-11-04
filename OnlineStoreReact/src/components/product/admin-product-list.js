import React, { Component } from "react"
import { bindActionCreators } from "redux"
import { connect } from "react-redux"
import { fetchAdminProducts, deleteProduct, PRODUCT_EXCEL_DOWNLOAD_URL } from "../../actions/index"
import { Link } from "react-router-dom";

import Paging from "../paging"
// import Cart from "./cart"

class AdminProductList extends Component {

    componentWillMount() {
        const page = this.props.page;
        this.props.fetchAdminProducts(page);
    }

    componentWillReceiveProps(nextProps) {
        const page = nextProps.page;
        if (this.props.page !== page) {
            this.props.fetchAdminProducts(page);
        }
    }
    currencyFormat(num) {
        if (num != "") {
            num = parseFloat(num)
            return "$" + num
                .toFixed(2) // always two decimal digits
                .replace(",", ".") // replace decimal point character with ,
                .replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1.") //+ " €" // use . as a separator
        }
    }
    downloadExcel() {

        var xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function () {
            var a, today;
            if (xhttp.readyState === 4 && xhttp.status === 200) {
                a = document.createElement('a');
                a.href = window.URL.createObjectURL(xhttp.response);
                today = new Date();
                a.download = "Products_" + today.toDateString().split(" ").join("_") + ".xlsx";
                a.style.display = 'none';
                document.body.appendChild(a);
                return a.click();
            }
        };
        xhttp.open("GET", PRODUCT_EXCEL_DOWNLOAD_URL, true);
        xhttp.setRequestHeader("Content-Type", "application/json");
        xhttp.responseType = 'blob';
        xhttp.send();
    }
    deleteProduct(id) {
        if (id != 0 && id != undefined) {
            const page = this.props.page;
            bootbox.confirm({
                message: "You want to delete product! Are you sure?",
                buttons: {
                    confirm: {
                        label: 'Yes',
                        className: 'btn-success'
                    },
                    cancel: {
                        label: 'No',
                        className: 'btn-danger'
                    }
                },
                callback: function (result) {
                    if (result) {
                        this.props.deleteProduct(id).then(() => {
                            this.props.fetchAdminProducts(page);
                        });
                    }
                }.bind(this)
            });

        }
    }
    renderProducts() {
        return this.props.products.map((product) => {
            return (
                <tr id={product.ProductId} key={product.ProductId}>
                    <td> {product.ProductId} </td>
                    <td> {product.CategoryName} </td>
                    <td> {product.Name} </td>
                    <td> {this.currencyFormat(product.Price)} </td>
                    <td> {product.StockQuantity} </td>
                    <td>
                        <a className="btn btn-sm btn-danger pull-right" title="Delete" onClick={() => this.deleteProduct(product.ProductId)} >
                            <i className="glyphicon glyphicon-trash"></i>
                        </a>
                        <Link className="btn btn-sm btn-warning pull-right button-margin" title="Edit" to={"/admin/product/productform/" + product.ProductId} >
                            <i className="glyphicon glyphicon-edit"></i>
                        </Link>
                    </td>
                </tr>
            );
        })
    }
    render() {
        if (this.props.products.length == 0) {
            return (
                <div>Loading...</div>
            )
        }
        const marginright = {
            margin: "0 0 0 10px"
        }
        return (
            <div className="col-md-12 col-sm-12">
                <a style={marginright} href="javascript:void(0)" target="_blank" onClick={this.downloadExcel} className="btn btn-sm btn-success pull-right">
                    <i className="glyphicon glyphicon-download-alt"></i>
                    Excel Download
                </a>
                <Link to="/admin/product/productform" className="btn btn-sm btn-primary pull-right">
                    <i className="glyphicon glyphicon-plus"></i>
                    Add New Product </Link>
                <table className="table table-responsive">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>CategoryName</th>
                            <th>Product Name</th>
                            <th>Price</th>
                            <th>Quantity</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.renderProducts()}
                    </tbody>
                </table>
                <Paging url="/admin/products"
                    type="adminProducts"
                    PageSize={this.props.PageSize}
                    PageCount={this.props.PageCount}
                />
            </div>
        );
    }
}

function mapStateToProps(state) {
    return {
        products: state.products.products,
        PageSize: state.products.PageSize,
        PageCount: state.products.PageCount
    }
}
function mapDispatchToProps(dispatch) {
    return bindActionCreators({
        fetchAdminProducts: fetchAdminProducts,
        deleteProduct: deleteProduct
    }, dispatch);
}

export default connect(mapStateToProps, mapDispatchToProps)(AdminProductList)