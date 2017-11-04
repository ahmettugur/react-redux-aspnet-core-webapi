import React, { Component } from "react";
import Cart from "../cart/cart"
export default class MenuCart extends Component {
    render() {
        return (
            <ul className="nav navbar-nav navbar-right">
                <li className="dropdown">
                    <a href="#" className="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">My Cart <span className="caret"></span></a>
                    <Cart />
                </li>
            </ul>
        )
    }
}