import React, { Component } from "react";
import MenuItem from "./menu-item"

export default class AdminMenuItemList extends Component {
    render() {
        const path = this.props.path;
        return (
            <ul className={this.props.cssClass}>
                <MenuItem text="Home" cssClass={path === "/admin" ? "active" : ""} url="/admin" />
                <MenuItem text="Products" cssClass={path === "/admin/products" ? "active" : ""} url="/admin/products" />
                <MenuItem text="Categories" cssClass={path === "/admin/categories" ? "active" : ""} url="/admin/categories" />
            </ul>
        )
    }
}