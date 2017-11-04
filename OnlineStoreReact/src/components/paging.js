import React, { Component } from "react"
import PropTypes from 'prop-types';


export default class Paging extends Component {
    componentDidMount() {
        this.renderPaging(this.props);
    }
    componentWillReceiveProps(nextProps) {
        if (this.props.type == "products") {
            if (this.props.PageCount !== nextProps.PageCount || nextProps.CurrentCategory != this.props.CurrentCategory) {
                this.renderPaging(nextProps);
            }
        }
        else if (this.props.type == "adminProducts") {
            if (this.props.PageCount !== nextProps.PageCount) {
                this.renderPaging(nextProps);
            }
        }
    }
    renderPaging(props) {
        let currentPage = 1;
        if (this.context.router.route.match.params.page != undefined) {
            currentPage = this.context.router.route.match.params.page;
        }
        const pageCount = props.PageCount;
        const pageSize = props.PageSize;
        const url = props.url;
        const type = props.type;
        $('#pagination-here').bootpag({
            total: pageCount,          // total pages 
            page: currentPage,            // default page 
            maxVisible: pageSize,     // visible pagination 
            leaps: true         // next/prev leaps through maxVisible 
        }).on("page", function (event, num) {
            if (type == "products") {
                this.redirectProductsPage(num, url);
            }
            else if (type == "adminProducts") {
                this.redirectAdminProductsPage(num, url);
            }

        }.bind(this));
    }
    redirectProductsPage(num, url) {
        let currentCategory = 0;
        if (this.context.router.route.match.params.categoryId != undefined) {
            currentCategory = this.context.router.route.match.params.categoryId;
        }
        this.context.router.history.push(url + "/" + currentCategory + "/" + num)

    }
    redirectAdminProductsPage(num, url) {
        let currentCategory = 0;
        if (this.context.router.route.match.params.categoryId != undefined) {
            currentCategory = this.context.router.route.match.params.categoryId;
        }

        this.context.router.history.push(url + "/" + num)
    }

    render() {
        return (
            <div id="pagination-here">

            </div>
        )
    }
}

Paging.contextTypes = {
    router: PropTypes.object
}
