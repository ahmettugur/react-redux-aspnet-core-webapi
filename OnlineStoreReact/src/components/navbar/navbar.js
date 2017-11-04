import React, { Component } from "react";
import MenuList from "./menu-list";
import MenuToggle from "./menu-toggle";
import PropTypes from 'prop-types';


export default class Navbar extends Component {
    render() {
        const path = this.context.router.route.location.pathname;
        return (
            <div className="col-md-12 col-sm-12">
                <nav className="navbar navbar-default">
                    <div className="container-fluid">
                        <MenuToggle text="Sample Store" />
                        <MenuList path={path} />
                    </div>
                </nav>
            </div>
        )
    }
}
Navbar.contextTypes = {
    router: PropTypes.object
}