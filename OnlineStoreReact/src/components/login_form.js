import React, { Component } from "react";
import { reduxForm, Field } from "redux-form";
import { login } from "../actions/index";
import { bindActionCreators } from "redux";
import { connect } from "react-redux";
import PropTypes from "prop-types";
import BlockUi from 'react-block-ui';
import 'react-block-ui/style.css';

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
    constructor(props) {
        super(props);

        this.toggleBlocking = this.toggleBlocking.bind(this);
        this.state = {
            blocking: false,
        };
    }

    toggleBlocking() {
        this.setState({ blocking: !this.state.blocking });
    }
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

    componentWillReceiveProps(nextProps, message) {
        var status = this.props.status;
        var newstatus = nextProps.status;
        if (newstatus !== 0) {
            if (newstatus === 200) {
                if (nextProps.accessToken !== undefined && nextProps.accessToken !== "") {
                    this.toggleBlocking();
                    this.addLocalStoregeToken(nextProps);
                    this.context.router.history.push("/admin")
                }
            } else {
                this.toggleBlocking();
                alert("Test: " + nextProps.message);
            }

        }
    }

    onSubmit(props) {
        this.toggleBlocking();
        this.props.login(props);
    }
    render() {
        const { handleSubmit, submitting } = this.props
        return (
            <div className="col-md-12 col-sm-12">
                <BlockUi tag="div" blocking={this.state.blocking}>
                    <div className="container">
                        <form className="form-signin" onSubmit={handleSubmit(this.onSubmit.bind(this))}>
                            <h2 className="form-signin-heading">Please sign in</h2>
                            <Field name="Email" type="email" className="form-control" component={renderField} label="Email" />
                            <Field name="Password" type="password" className="form-control" component={renderField} label="Password" />
                            <div>
                                <button type="submit" className="btn btn-primary" disabled={submitting}>Submit</button>
                            </div>
                            <div style={{ marginTop: "15px" }}>
                                Email : admin@admin.com
                            <br />
                                Password : 123456
                        </div>
                        </form>
                    </div>
                </BlockUi>
            </div>
        );
    }
}

function mapStateToProps(state) {
    return {
        accessToken: state.accessToken.accessToken,
        message: state.accessToken.message,
        status: state.accessToken.status,
        statusClass: state.accessToken.statusClass
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

LoginForm.contextTypes = {
    router: PropTypes.object
}
