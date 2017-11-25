import React, { Component } from "react";
import CategoryInsertForm from "./category-insert";
import CategoryUpdateForm from "./category-update";


export default class CategoryForm extends Component {

    render() {
        const categoryId = this.props.match.params.categoryId;
        console.log("categoryId: " + categoryId)

        if (categoryId !== undefined) {
            return (
                <CategoryUpdateForm categoryId={categoryId} />
            );
        } else {
            return (
                <CategoryInsertForm />
            );
        }


    }

}
