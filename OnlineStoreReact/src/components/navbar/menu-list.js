import React, { Component } from "react";
import MenuCart from "./menu-cart";
import MenuItemList from "./menu-item-list";

export default class MenuList extends Component {
    render() {
        const path = this.props.path;
        return (
            <div className="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <MenuItemList cssClass="nav navbar-nav" path={path} />
                <MenuCart />
            </div>
        )
    }
}