import React, { Component } from "react";
import AdminMenuList from "./admin-menu-list";
import MenuToggle from "./menu-toggle";
import PropTypes from "prop-types";

export default class AdminNavbar extends Component {
    // static contextTypes = {
    //     router: PropTypes.object
    // }
    render() {
        const path = this.context.router.route.location.pathname;
        return (
            <div className="col-md-12 col-sm-12">
                <nav className="navbar navbar-default">
                    <div className="container-fluid">
                        <MenuToggle text="Admin Panel" />
                        <AdminMenuList path={path} />
                    </div>
                </nav>
            </div>
        )
    }
}
AdminNavbar.contextTypes = {
    router: PropTypes.object
}