import React, { Component } from "react";
import MenuItem from "./menu-item"

export default class MenuItemList extends Component {
    render() {
        const path = this.props.path;
        return (
            <ul className={this.props.cssClass}>
                <MenuItem text="Home" cssClass={path === "/web" ? "active" : ""} url="/web" />
                <MenuItem text="Products" cssClass={path === "/web/products" ? "active" : ""} url="/web/products" />
                <MenuItem text="My Cart" cssClass={path === "/web/cart" ? "active" : ""} url="/web/cart" />
            </ul>
        )
    }
}