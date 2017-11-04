import React, { Component } from "react";
import AdminMenuItemList from "./admin-menu-item-list";

export default class AdminMenuList extends Component {
    render() {
        const path = this.props.path;
        return (
            <div className="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <AdminMenuItemList cssClass="nav navbar-nav" path={path} />
            </div>
        )
    }
}