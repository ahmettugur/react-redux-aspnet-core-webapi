import React, { Component } from 'react';
import AdminProductList from "./admin-product-list"

export default class AdminProducts extends Component {
  render() {
    const productId = this.props.match.params.productId == undefined ? 0 : this.props.match.params.productId;
    const page = this.props.match.params.page == undefined ? 1 : this.props.match.params.page
    console.log(productId);
    return (
      <AdminProductList page={page} productId={productId} />
    );
  }
}
