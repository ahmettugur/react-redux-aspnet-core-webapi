import React, { Component } from 'react';
import { Route } from 'react-router-dom'
import AdminNavbar from "./navbar/admin-navbar";
// import LoginForm from "./login_form";
import AdminProducts from "./product/admin-products";
import AdminCategories from "./category/admin-category-list";
import ProductForm from "./product/product-form";
import CategoryForm from "./category/category-form";
import PropTypes from "prop-types";
import injectTapEventPlugin from "react-tap-event-plugin";
injectTapEventPlugin();


export default class AdminApp extends Component {
  exprireTimeControl() {
    var hours = 10; // Reset when storage is more than 24hours
    var now = new Date().getTime();
    var setupTime = localStorage.getItem('setupTime');

    if (now - setupTime > hours * 60 * 60 * 1000) {
      localStorage.removeItem("accessToken")
      localStorage.removeItem("setupTime")
    }
  }
  componentWillMount() {
    this.exprireTimeControl();
    var accessToken = localStorage.getItem('accessToken');

    if (accessToken == null) {
      this.context.router.history.push("/login")
      this.context.router.history.replace("/login")
    }

  }
  render() {

    return (
      <div className="container">
        <AdminNavbar />
        <div>
          <Route path="/admin/products/:page?" component={AdminProducts} />
          <Route path="/admin/product/productform/:productId?" component={ProductForm} />
          <Route path="/admin/categories/:page?" component={AdminCategories} />
          <Route path="/admin/category/categoryform/:categoryId?" component={CategoryForm} />
        </div>
      </div>
    );
  }
}

AdminApp.contextTypes = {
  router: PropTypes.object
}


