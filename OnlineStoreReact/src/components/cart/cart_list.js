import React, { Component } from "react";
import { fetchCart } from "../../actions/index";
import { bindActionCreators } from "redux"
import { connect } from "react-redux";
//import getCart from "./cart-store";
import { Link } from "react-router-dom"
import $ from 'jquery';
import 'bootstrap/dist/css/bootstrap.css';
import bootbox from "bootbox"
window.jQuery = $;
require('bootstrap');

class CartList extends Component {
    removeItem(productId) {
        var cart = { CartLines: [], Total: 0, Message: "" }

        var item = this.props.cartLines.filter(function (el) {
            if (el.Product.Id !== productId) {
                cart.Total += parseFloat(el.Product.Price * el.Quantity);
                return el;
            }
        });
        cart.CartLines = item;

        localStorage.setItem('cart', JSON.stringify(cart));
        this.props.fetchCart();
        //this.renderCart(cart);
    }
    removeFromCart(productId) {
        bootbox.confirm({
            message: "You want to delete product from your cart! Are you sure?",
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
                    this.removeItem(productId);
                }
            }.bind(this)
        });
    }
    componentWillMount() {
        this.props.fetchCart();
    }
    // componentWillReceiveProps(nextProps) {
    //     if (this.props.total != nextProps.total) {
    //         this.props.fetchCart();
    //     }
    // }
    // currencyFormat(num) {
    //     return "$" + num.toFixed(2).replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1.")
    // }
    currencyFormat(num) {
        if (num !== "") {
            num = parseFloat(num)
            return "$" + num
                .toFixed(2) // always two decimal digits
                .replace(",", ".") // replace decimal point character with ,
                .replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1.") //+ " €" // use . as a separator
        }
    }
    renderCart() {
        return this.props.cartLines.map((cartLine) => {
            return (
                <tr key={cartLine.Product.Id}>
                    <td>{cartLine.Product.Name}</td>
                    <td style={{ textAlign: 'right' }}>{this.currencyFormat(cartLine.Product.Price)}</td>
                    <td style={{ textAlign: 'right' }}>{cartLine.Quantity}</td>
                    <td className="text-right">
                        <a className="btn btn-xs btn-danger pull-right" onClick={() => this.removeFromCart(cartLine.Product.Id)} >
                            <span className="glyphicon glyphicon-remove"></span>
                        </a>
                    </td>
                </tr>
            )
        });
    }
    render() {
        if (this.props.cartLines.length === 0) {
            return (
                <div>Loading...</div>
            )
        }
        return (
            <div className="col-md-10  col-sm-10">
                <table className="table table-responsive">
                    <thead>
                        <tr>
                            <th>Product Name</th>
                            <th style={{ textAlign: 'right' }}>Price</th>
                            <th style={{ textAlign: 'right' }} >Quantity</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.renderCart()}
                        <tr>
                            <td></td>
                            <td></td>
                            <td style={{ textAlign: 'right' }}>
                                <h3>Total</h3>
                            </td>
                            <td className="text-right" style={{ verticalAlign: 'middle' }}>
                                <strong>{this.currencyFormat(this.props.total)}</strong>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td>
                                <Link className="btn btn-xs btn-default" to="/web/products">
                                    <span className="glyphicon glyphicon-shopping-cart"></span>
                                    Continue Shopping
                                </Link>
                            </td>
                            <td className="text-right">
                                <a className="btn btn-xs btn-success">
                                    <span className="glyphicon glyphicon-shopping-play"></span>
                                    Go to Checkout
                                </a>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        )
    }

}

function mapStateToProps(state) {
    return {
        cartLines: state.cart.cartLines,
        total: state.cart.Total
    }
}

function mapDispatchToProps(dispatc) {
    return bindActionCreators({
        fetchCart: fetchCart
    }, dispatc);
}

export default connect(mapStateToProps, mapDispatchToProps)(CartList);