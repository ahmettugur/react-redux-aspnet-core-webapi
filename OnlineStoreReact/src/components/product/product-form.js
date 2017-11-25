import React, { Component } from "react"
import ProductUpdateForm from "./product-update"
import ProductInsertForm from "./product-insert"
// import injectTapEventPlugin from "react-tap-event-plugin";
// injectTapEventPlugin();


export default class ProductForm extends Component {

    render() {
        const productId = this.props.match.params.productId
        if (productId !== undefined) {
            return (
              <ProductUpdateForm productId={productId} />
            )
        }
        return (
            <ProductInsertForm />
        )
    }
}