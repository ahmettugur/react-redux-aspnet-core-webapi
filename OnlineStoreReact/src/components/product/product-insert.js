import React, { Component } from "react";
import { Link } from "react-router-dom";
import { fetchCategories, addproduct } from "../../actions/index";
import { bindActionCreators } from "redux";
import { connect } from "react-redux";
import { Field, reduxForm } from "redux-form";
import TextField from "material-ui/TextField";
import SelectField from "material-ui/SelectField";
import MenuItem from "material-ui/MenuItem";
import MuiThemeProvider from "material-ui/styles/MuiThemeProvider";
import getMuiTheme from "material-ui/styles/getMuiTheme";
import PropTypes from "prop-types";

const validate = values => {
    const errors = {}
    const requiredFields = ['Name', 'Price', 'StockQuantity', 'CategoryId', 'Details']
    requiredFields.forEach(field => {
        if (!values[field]) {
            errors[field] = 'Required'
        }
    })
    return errors
}

const renderTextField = ({ input, label, type, meta: { touched, error }, ...custom }) => (

    <TextField hintText={label}
        floatingLabelText={label}
        className="text-field"
        type={type}
        errorText={touched && error}
        {...custom}
        {...input}
    />
)


const renderSelectField = ({ input, label, meta: { touched, error }, children, ...custom }) => (

    <SelectField
        floatingLabelText={label}
        className="select-field"
        errorText={touched && error}
        {...input}
        onChange={(event, index, value) => input.onChange(value)}
        children={children}
        {...custom} />

)

export class ProductInsertForm extends Component {

    componentWillMount() {
        this.props.fetchCategories();
    }

    onSubmit(props) {
        this.props.addproduct(props).then(() => {
            this.context.router.history.push("/admin/products")
            this.context.router.history.replace("/admin/products")
        });
    }
    renderCategoryItem() {
        return this.props.categories.map((category) => {
            return (
                <MenuItem key={category.Id} value={category.Id} primaryText={category.Name} />
            );
        })
    }

    render() {

        const { handleSubmit, pristine, reset, submitting } = this.props
        return (
            <div className="col-md-12 col-sm-12">
                <div className="page-header">
                    <h4 className="text-primary"> Add a new product </h4>
                </div>
                <div className="container">
                    <MuiThemeProvider muiTheme={getMuiTheme()}>
                        <form onSubmit={handleSubmit(this.onSubmit.bind(this))}>
                            <div className="form-group">
                                <Field type="text" name="Name" component={renderTextField} label="Product Name" />
                            </div>
                            <div>
                                <Field type="number" name="Price" component={renderTextField} label="Price" />
                            </div>
                            <div>
                                <Field type="number" name="StockQuantity" component={renderTextField} label="Stock Quantity" />
                            </div>
                            <div>
                                <Field name="CategoryId" component={renderSelectField} label="Category">
                                    {this.renderCategoryItem()}
                                </Field>
                            </div>
                            <div>
                                <Field name="Details" component={renderTextField} label="Details" multiLine={true} rows={2} />
                            </div>
                            <div>
                                <button type="submit" className="btn btn-primary" disabled={pristine || submitting}>Save</button>
                                <button type="button" className="btn btn-default" disabled={pristine || submitting} onClick={reset}>Clear Values </button>
                                <Link to="/admin/products" className="btn btn-default">Go Back</Link>
                            </div>
                        </form>
                    </MuiThemeProvider>
                </div>
            </div>
        )
    }
}


function mapStateToProps(state) {
    return {
        categories: state.categories.categories
    }
}

function mapDispatchToProps(dispatch) {
    return bindActionCreators({
        fetchCategories: fetchCategories,
        addproduct: addproduct,
    }, dispatch);
}

export default connect(mapStateToProps, mapDispatchToProps)(reduxForm({
    form: 'productInsertForm',
    validate
})(ProductInsertForm));

ProductInsertForm.contextTypes = {
    router: PropTypes.object
}


// ProductInsertForm = reduxForm({
//     form: 'ProductInsertForm',
//     validate
// })(ProductInsertForm)

// ProductInsertForm = connect(mapStateToProps, mapDispatchToProps)(ProductInsertForm)

// export default ProductInsertForm