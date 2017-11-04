import React, { Component } from "react"
import { connect } from "react-redux"
import CategoryItem from "./category_item"
import { fetchCategories } from "../../actions/index"


class CategoryList extends Component {

    //5 Saniyede bir fnksşyon çağırılarak data yenileniyor.

    /*componentWillReceiveProps(nextProps) {
        console.log(nextProps);
        if (this.props.categoryList !== nextProps.categoryList) {
            clearTimeout(this.timeout);
            this.timeout = setTimeout(() => this.props.fetchCategory(), 5000);
        }
    }
    componentWillUnmount() {
        clearTimeout(this.timeout);
    }
    startPoll() {
        this.timeout = setTimeout(() => this.props.fetchCategory(), 5000);
    }*/


    componentWillMount() {
        this.props.fetchCategories();
    }
    renderCategoryItem() {
        return this.props.categories.map((category) => {
            return (
                <CategoryItem key={category.Id} categoryName={category.Name} catId={category.Id} currentCategory={this.props.categoryId} />
            );
        });
    }
    render() {
        if (this.props.categories == 0) {
            return (
                <div>Loading...</div>
            )
        }
        return (
            <div className="col-md-2 col-sm-2">
                <div className="list-group">
                    {this.renderCategoryItem()}
                </div>
            </div>
        );
    }

}

function mapStateToProps(state) {
    return { categories: state.categories.categories }
}

export default connect(mapStateToProps, { fetchCategories })(CategoryList)