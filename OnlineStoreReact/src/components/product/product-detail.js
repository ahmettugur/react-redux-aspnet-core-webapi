import React, { Component } from "react";
import { connect } from "react-redux";
import { productDetail, addToCart } from "../../actions/index";

import $ from "jquery";
import "bootstrap/dist/css/bootstrap.css";
import bootbox from "bootbox";
window.jQuery = $;
require("bootstrap");

const signalR = require("@aspnet/signalr");

class ProductDetail extends Component {
  constructor(props) {
    super(props);

    this.state = {
      hubConnection: null
    };
  }
  componentWillMount() {
    const productId = this.props.match.params.productId;
    this.props.productDetail(productId);
  }

  componentDidMount = () => {

    const productId = this.props.match.params.productId;

    const hubConnection = new signalR.HubConnectionBuilder()
      .withUrl("http://localhost:1977/producthub")
      .configureLogging(signalR.LogLevel.Information)
      .build();

    //this.props.productDetail(5);

    this.setState({ hubConnection }, () => {
      this.state.hubConnection
        .start()
        .then(() => console.log("SignalR Connection started!"))
        .catch(err => console.log("Error while establishing connection :("));
      this.state.hubConnection.on("SetConnectionId", data => {
        var result = hubConnection.invoke("ConnectGroup", productId, data);
      });
      this.state.hubConnection.on("ChangeProductValue", data => {
        if (data.stockQuantity <= 0) {
          bootbox.alert({
            message: "Product stock chnaged!",
            size: "small"
          });
         
        }
        this.setDisplay(data.stockQuantity)
      });
    });
  };
  setDisplay(stockQuantity){
    if (stockQuantity <= 0) {
      $("#quantityBox").removeClass("displayBlock");
      $("#addtoCartBox").removeClass("displayBlock");

      $("#quantityBox").addClass("displayNone");
      $("#addtoCartBox").addClass("displayNone");


      $("#outofStockBox").removeClass("displayNone");
      $("#outofStockBox").addClass("displayBlock");
    }else{
      $("#quantityBox").removeClass("displayNone");
      $("#addtoCartBox").removeClass("displayNone");

      $("#quantityBox").addClass("displayBlock");
      $("#addtoCartBox").addClass("displayBlock");


      $("#outofStockBox").removeClass("displayBlock");
      $("#outofStockBox").addClass("displayNone");
    }
  }
  addToCarts() {
    const productId = this.props.match.params.productId;
    this.props.addToCart(productId).then(() => {
      bootbox.alert({
        message: "Your product added succcesfully!",
        size: "small"
      });
    });
    //$('.modal').modal('show');
  }
  decrease() {
    var val = document.getElementById("quantity").value;
    if (!isNaN(val)) {
      if (parseInt(val) - 1 > 0) {
        val--;
      }
      document.getElementById("quantity").value = val;
    } else {
      document.getElementById("quantity").value = "1";
    }
  }
  increment() {
    var val = document.getElementById("quantity").value;
    if (!isNaN(val)) {
      val++;
      document.getElementById("quantity").value = val;
    } else {
      document.getElementById("quantity").value = "1";
    }
  }
  renderproduct(product) {
    var imgStyle = {
      width: "100%"
    };
    var priceStyle = {
      marginTop: "0%"
    };
    var borderStyle = {
      border: "0px solid gray"
    };
    var paddingBottom = {
      paddingBottom: "20px"
    };
    var marginRight = {
      marginRight: "20px"
    };
    var cursorPointer = {
      cursor: "pointer"
    };
    var displayStyle = {
      display: "inline-block"
    };


    let displayClass = "";
    let displayClass2 = "";

    if (product.stockQuantity > 0) {
      displayClass = "section displayBlock";
      displayClass2 = "section displayNone";
    } else {
      displayClass = "section displayNone";
      displayClass2 = "section displayBlock";
    }


    return (
      <div>
        <div className="col-xs-4 item-photo">
          <img style={imgStyle} src="/images/product.jpg" />
        </div>
        <div className="col-xs-5" style={borderStyle}>
          <h3>{product.name}</h3>
          <h6 className="title-price">
            <small>Price</small>
          </h6>
          <h3 style={priceStyle}>
            $ <span id="price">{product.price}</span>
          </h3>

          <div className={displayClass} style={paddingBottom} id="quantityBox">
            <h6 className="title-attr">
              <small>Quantity</small>
            </h6>
            <div>
              <div
                className="btn-minus"
                onClick={() => this.decrease()}
                style={displayStyle} >
                <span className="glyphicon glyphicon-minus" />
              </div>
              <input defaultValue="1" id="quantity" />
              <div
                className="btn-plus"
                onClick={() => this.increment()}
                style={displayStyle}>
                <span className="glyphicon glyphicon-plus" />
              </div>
            </div>
          </div>
          <div className={displayClass} style={paddingBottom} id="addtoCartBox">
            <button
              onClick={() => {
                this.addToCarts();
              }}
              className="btn btn-success">
              <span
                style={marginRight}
                className="glyphicon glyphicon-shopping-cart"
                aria-hidden="true" />
              Add to cart
            </button>
          </div>
          <div className={displayClass2} style={paddingBottom} id="outofStockBox">
            <span
              style={marginRight}
              aria-hidden="true"/>
            The product is outof stock
          </div>
        </div>

      </div>
    );
  }

  render() {
    if (!this.props.product) {
      return <h1>Loading</h1>;
    } else {
      return this.renderproduct(this.props.product);
    }
  }
}

const mapStateToProps = state => {
  return {
    product: state.products.product
  };
};

const mapDispatchToProps = {
  productDetail: productDetail,
  addToCart: addToCart
};

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(ProductDetail);
