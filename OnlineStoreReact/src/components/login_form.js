import React, { Component } from "react";
import { reduxForm, Field } from "redux-form";
import { login } from "../actions/index";
import { bindActionCreators } from "redux";
import { connect } from "react-redux";
import PropTypes from "prop-types";

const validate = values => {
    const errors = {}
    if (!values.Password) {
        errors.Password = 'Required'
    }
    if (!values.Email) {
        errors.Email = 'Required'
    } else if (!/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i.test(values.Email)) {
        errors.Email = 'Invalid email address'
    }
    return errors
}
const renderField = ({ input, label, type, className, meta: { touched, error, warning } }) => (
    <div className="form-group">
        <label>{label}</label>
        <input {...input} placeholder={label} className={className} type={type} />
        {touched && ((error && <span className="form-text text-danger">{error}</span>) || (warning && <span>{warning}</span>))}
    </div>
)

class LoginForm extends Component {

    getAccessToken() {
        this.exprireTimeControl();
        var accessToken = localStorage.getItem('accessToken');
        return accessToken;
    }
    exprireTimeControl() {
        var hours = 10; // Reset when storage is more than 24hours
        var now = new Date().getTime();
        var setupTime = localStorage.getItem('setupTime');

        if (now - setupTime > hours * 60 * 60 * 1000) {
            localStorage.removeItem("accessToken")
            localStorage.removeItem("setupTime")
        }
    }
    addLocalStoregeToken(props) {
        var tokenData = {
            accessToken: props.accessToken,
            message: props.message
        }
        var hours = 10; // Reset when storage is more than 24hours
        var now = new Date().getTime();
        localStorage.removeItem("setupTime")
        localStorage.setItem('setupTime', now);
        localStorage.setItem('accessToken', JSON.stringify(tokenData))
    }
    componentWillMount() {
        var accessToken = this.getAccessToken();
        if (accessToken != null) {
            this.props.login(null);
        }
    }

    componentWillReceiveProps(nextProps,message) {
        //if (accessToken != null) {
        if (nextProps.accessToken != undefined && nextProps.accessToken != "") {
            this.addLocalStoregeToken(nextProps);
            this.context.router.history.push("/admin")

        }
        // }
    }

    onSubmit(props) {
        this.props.login(props);
    }
    render() {
        const { handleSubmit, submitting } = this.props
        return (
            <div className="col-md-12 col-sm-12">
                <div className="container">
                    <form className="form-signin" onSubmit={handleSubmit(this.onSubmit.bind(this))}>
                        <h2 className="form-signin-heading">Please sign in</h2>
                        <Field name="Email" type="email" className="form-control" component={renderField} label="Email" />
                        <Field name="Password" type="password" className="form-control" component={renderField} label="Password" />
                        <div>
                            <button type="submit" className="btn btn-primary" disabled={submitting}>Submit</button>
                        </div>
                        <div style={{marginTop:"15px"}}> 
                            Email : admin@admin.com
                            <br/>
                            Password : 123456
                        </div>
                    </form>
                </div>
            </div>
        );
    }
}

function mapStateToProps(state) {
    return {
        accessToken: state.accessToken.accessToken,
        message: state.accessToken.message
    }
}

function mapDispatchToProps(dispatch) {
    return bindActionCreators({
        login: login
    }, dispatch);
}

export default connect(mapStateToProps, mapDispatchToProps)(reduxForm({
    form: 'loginForm',
    validate
})(LoginForm));

// LoginForm = reduxForm({
//     form: 'loginForm', // a unique identifier for this form
//     validate
// })(LoginForm)




// const formConfig = {
//   form: 'loginForm',
//   validate
// };

// export default reduxForm(formConfig, mapStateToProps, mapDispatchToProps)(LoginForm);
// LoginForm = connect(mapStateToProps, mapDispatchToProps)(LoginForm)
// export default LoginForm

LoginForm.contextTypes = {
    router: PropTypes.object
}





/*LoginForm = reduxForm({
    form: 'loginForm', // a unique identifier for this form
    validate
})(LoginForm)

LoginForm = connect(mapStateToProps, mapDispatchToProps)(LoginForm)
export default LoginForm*/