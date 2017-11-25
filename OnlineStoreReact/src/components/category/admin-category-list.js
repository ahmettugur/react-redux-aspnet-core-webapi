import React, { Component } from "react"
import { connect } from "react-redux"
import { bindActionCreators } from "redux"
import { fetchCategories, deleteCategory } from "../../actions/index"
import { Link } from "react-router-dom"
import BlockUi from 'react-block-ui';
import 'react-block-ui/style.css';
import showAlertBox from "../../tools/tools"
import $ from 'jquery';
import 'bootstrap/dist/css/bootstrap.css';
import bootbox from "bootbox"
window.jQuery = $;
require('bootstrap');


class AdminCategoryList extends Component {
    constructor(props) {
        super(props);

        //this.toggleBlocking = this.toggleBlocking.bind(this);
        this.state = {
            blocking: false,
        };
    }

    toggleBlocking(status) {
        this.setState({ blocking: status });
    }
    componentWillMount() {
        console.log(this.props.status);
        this.toggleBlocking(true)
        this.props.fetchCategories();
    }
    componentWillReceiveProps(nextProps) {
        this.toggleBlocking(false)
        if (nextProps.status === 0 || nextProps.status === 204) {
            this.toggleBlocking(true)
            showAlertBox("Category was deleted successfully", "alert-success");
            this.props.fetchCategories();
        }
        else if (nextProps.status === 400) {
            showAlertBox(nextProps.message, "alert-danger");
        }
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
                    this.toggleBlocking(true)
                    this.props.deleteCategory(categoryId);
                    //this.props.fetchCategories();
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
        if (this.props.categories.length === 0) {
            return (<BlockUi tag="div" blocking={this.state.blocking}> <div>Loading...</div> </BlockUi>)
        }
        return (
            <div className="col-md-12 col-sm-12">
                <BlockUi tag="div" blocking={this.state.blocking}>
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
                </BlockUi>
            </div>
        )
    }

}

function mapStateToProps(state) {
    return {
        categories: state.categories.categories,
        message: state.categories.message,
        status: state.categories.status,
        statusClass: state.categories.statusClass
    }
}


function mapDispatchToprops(dispatch) {
    return bindActionCreators({
        fetchCategories: fetchCategories,
        deleteCategory: deleteCategory
    }, dispatch);
}

export default connect(mapStateToProps, mapDispatchToprops)(AdminCategoryList)