import React, { Component } from "react"
import { connect } from "react-redux"
import { bindActionCreators } from "redux"
import { fetchCategories, deleteCategory } from "../../actions/index"
import { Link } from "react-router-dom"



class AdminCategoryList extends Component {

    componentWillMount() {
        this.props.fetchCategories();
    }
    deletecategory(categoryId) {
        bootbox.confirm({
            message: "You want to delete category! Are you sure?",
            buttons: {
                confirm: {
                    label: 'Yes',
                    className: 'btn-success'
                },
                cancel: {
                    label: 'No',
                    className: 'btn-danger'
                }
            },
            callback: function (result) {
                if (result) {
                    this.props.deleteCategory(categoryId).then(() => {
                        this.props.fetchCategories();
                    })
                }
            }.bind(this)
        });

    }
    renderCategory() {
        return this.props.categories.map((category) => {
            return (
                <tr key={category.Id}>
                    <td>{category.Id} </td>
                    <td>{category.Name} </td>
                    <td>{category.Description} </td>
                    <td>
                        <a className="btn btn-sm btn-danger pull-right" title="Delete" onClick={() => this.deletecategory(category.Id)} >
                            <i className="glyphicon glyphicon-trash"></i>
                        </a>
                        <Link className="btn btn-sm btn-warning pull-right button-margin" title="Edit" to={"/admin/category/categoryform/" + category.Id} >
                            <i className="glyphicon glyphicon-edit"></i>
                        </Link>
                    </td>
                </tr>
            )
        })
    }

    render() {
        if (this.props.categories.length == 0) {
            return (<div> Loading...</div>)
        }
        return (
            <div className="col-md-12 col-sm-12">
                <Link to="/admin/category/categoryform" className="btn btn-sm btn-primary pull-right">
                    <i className="glyphicon glyphicon-plus"></i>
                    Add New Category </Link>
                <table className="table table-responsive">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Category Name</th>
                            <th>Description</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.renderCategory()}
                    </tbody>
                </table>
            </div>
        )
    }

}

function mapStateToProps(state) {
    return {
        categories: state.categories.categories
    }
}


function mapDispatchToprops(dispatch) {
    return bindActionCreators({
        fetchCategories: fetchCategories,
        deleteCategory: deleteCategory
    }, dispatch);
}

export default connect(mapStateToProps, mapDispatchToprops)(AdminCategoryList)