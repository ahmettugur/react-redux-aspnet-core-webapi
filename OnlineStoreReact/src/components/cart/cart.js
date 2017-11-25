import React, { Component } from "react";
import { bindActionCreators } from "redux";
// import getCard from "../store/cart-store";
import { Link } from "react-router-dom";
import { connect } from "react-redux";
import { fetchCart } from "../../actions/index";

class Cart extends Component {
    componentWillMount() {
        this.props.fetchCart();
    }
    componentWillReceiveProps(nextProps) {
        if (this.props.Total !== nextProps.Total) {
            this.props.fetchCart();
        }
    }
    currencyFormat(num) {
        return "$" + num
            .toFixed(2) // always two decimal digits
            .replace(",", ".") // replace decimal point character with ,
            .replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1.") //+ " €" // use . as a separator
    }
    renderCartLine() {
        return this.props.cartLines.map((cartLine) => {
            return (
                <li key={cartLine.Product.Name}>
                    <a href="javascript:void(0);">
                        {cartLine.Product.Name}
                        <span className="badge">
                            {cartLine.Quantity}
                        </span>
                    </a>
                </li>
            )
        })
    }
    render() {
        if (this.props.cartLines.length === 0) {
            return (
                <ul className="dropdown-menu">
                    <li><a href="javascript:void(0);">
                        <span className="glyphicon glyphicon-align-left glyphicon-shopping-cart" aria-hidden="true">
                            0
                        </span>
                    </a>
                    </li>
                    <li>
                        <a>
                            Go to cart details
                    </a>
                    </li>
                </ul>
            )
        }
        return (
            <ul className="dropdown-menu">
                {this.renderCartLine()}
                <li role="separator" className="divider"></li>
                <li><a href="javascript:void(0);">
                    <span className="glyphicon glyphicon-align-left glyphicon-shopping-cart" aria-hidden="true">
                        {this.currencyFormat(this.props.total)}
                    </span>
                </a>
                </li>
                <li>
                    <Link to="/web/cart">
                        Go to cart Details
                    </Link>
                </li>
            </ul>
        );
    }

}
function mapStateToProps(state) {
    return {
        cartLines: state.cart.cartLines,
        total: state.cart.Total
    }
}
function mapDispatchToProps(dispatch) {
    return bindActionCreators({
        fetchCart: fetchCart
    }, dispatch);
}

export default connect(mapStateToProps, mapDispatchToProps)(Cart)