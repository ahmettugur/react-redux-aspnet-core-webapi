import React, { Component } from 'react';
import { Route } from 'react-router-dom'
import Navbar from "./navbar/navbar"
import CategoryList from "./category/category_list"
import Products from "./product/products"
import CartList from "./cart/cart_list"




export default class App extends Component {
  render() {
    const categoryId = this.props.match.params.categoryId === undefined ? 0 : this.props.match.params.categoryId;
    return (
      <div className="container">
        <Navbar />
        <div>
          <CategoryList categoryId={categoryId} />
          <Route path="/web/products/:categoryId?/:page?" component={Products} />
          <Route path="/web/cart" component={CartList} />
        </div>
      </div>
    );
  }
}