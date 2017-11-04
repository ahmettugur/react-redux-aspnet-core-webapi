import React, { Component } from "react"
import { Link } from "react-router-dom"

export default class CategoryItem extends Component {
    render() {
        const currentCategory = this.props.currentCategory;
        const page = 1;//this.props.page;
        const categoryId = this.props.catId
        var cssClass = categoryId == currentCategory ? "list-group-item active" : "list-group-item";

        return (
            <Link id={"data-" + categoryId} to={"/web/products/" + this.props.catId + "/" + page} className={cssClass}>
                {this.props.categoryName}
            </Link>

        );
    }
}