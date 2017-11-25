import React, { Component } from "react"
import { bindActionCreators } from "redux"
import { connect } from "react-redux"
import { fetchProducts, addToCart } from "../../actions/index"
import Paging from "../paging"
// import Cart from "./cart"

import $ from 'jquery';
import 'bootstrap/dist/css/bootstrap.css';
import bootbox from "bootbox"
window.jQuery = $;
require('bootstrap');

class ProductList extends Component {

    componentWillMount() {
        const categoryId = this.props.categoryId;
        const page = this.props.page;
        this.props.fetchProducts(categoryId, page);
        // this.props.addToCart(1);
    }
    currencyFormat(num) {
        if (num !== "") {
            num = parseFloat(num)
            return "$" + num
                .toFixed(2) // always two decimal digits
                .replace(",", ".") // replace decimal point character with ,
                .replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1.") //+ " €" // use . as a separator
        }
    }
    componentWillReceiveProps(nextProps) {

        const categoryId = nextProps.categoryId;
        const page = nextProps.page;

        if (this.props.categoryId !== categoryId || this.props.page !== page) {
            this.props.fetchProducts(categoryId, page);

        }
    }

    addToCarts(id) {
        this.props.addToCart(id).then(() => {
            bootbox.alert({
                message: "Your product added succcesfully!",
                size: 'small'
            });
        });
        //$('.modal').modal('show');
    }
    renderProducts() {
        return this.props.productList.map((product) => {
            return (
                <div key={product.Id} className="col-sm-3 col-md-3 product-list">
                    <div className="thumbnail">
                        <img src="/images/product.jpg" alt="..." />
                        <div className="caption">
                            <div className="product-title">{product.Name}</div>
                            <div>
                                <span className="pull-left">
                                    <strong>
                                        {this.currencyFormat(product.Price)}
                                    </strong>
                                </span>
                                <a onClick={() => this.addToCarts(product.Id)} className="btn btn-xs btn-success pull-right" role="button" >
                                    Add To Cart
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            );
        })
    }
    render() {
        if (this.props.productList.length === 0) {
            return (
                <div>Loading...</div>
            )
        }

        return (
            <div className="col-md-10 col-sm-10">
                <div className="row">
                    {this.renderProducts()}
                </div>
                <Paging url="/web/products"
                    type="products"
                    PageSize={this.props.PageSize}
                    PageCount={this.props.PageCount}
                    CurrentCategory={this.props.categoryId}
                />
            </div>
        );
    }
}

function mapStateToProps(state) {
    return {
        productList: state.products.products,
        PageSize: state.products.PageSize,
        PageCount: state.products.PageCount
    }
}
function mapDispatchToProps(dispatch) {
    return bindActionCreators({
        fetchProducts: fetchProducts,
        addToCart: addToCart
        // callMessage: callMessage 
    }, dispatch);
}

export default connect(mapStateToProps, mapDispatchToProps)(ProductList)


// export default connect(mapStateToProps, { fetchProducts })(ProductList)
