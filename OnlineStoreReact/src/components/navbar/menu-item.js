import React, { Component } from "react"
import { Link } from "react-router-dom";

export default class MenuItem extends Component {
    render() {
        return(
            <li className={this.props.cssClass}>
                
                <Link to={this.props.url}>{this.props.text}</Link>
            </li>
        );
    }
    
}