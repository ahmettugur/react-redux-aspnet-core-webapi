import React, { Component } from 'react';
import ProductList from "./product_list"
import PropTypes from "prop-types"

export default class Products extends Component {
  render() {
    const categoryId = this.props.match.params.categoryId == undefined ? 0 : this.props.match.params.categoryId;
    const page = this.props.match.params.page == undefined ? 1 : this.props.match.params.page
    return (
      <ProductList categoryId={categoryId} page={page} />
    );
  }
}