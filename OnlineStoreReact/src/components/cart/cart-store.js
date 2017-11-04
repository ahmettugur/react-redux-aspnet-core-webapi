import _ from "lodash"

function setCart(data) {
    var storageCart = localStorage.getItem("cart");
    var CartLine = { Product: {}, Quantity: 0 };
    var cart = { CartLines: [], Total: 0, Message: "" }

    if (storageCart == null) {
        CartLine.Product = data;
        CartLine.Quantity = 1;
        cart.CartLines.push(CartLine);
    }
    else {
        cart = JSON.parse(storageCart);
        var isExist = _.some(cart.CartLines, function (cartLine) {
            if (cartLine.Product.Id == data.Id) {
                cartLine.Quantity++;
                return true;
            }
        });

        if (!isExist) {
            CartLine.Product = data;
            CartLine.Quantity = 1;
            cart.CartLines.push(CartLine);
        }
    }
    var totalPrice = _.reduce(cart.CartLines, function (totalPrice, cartLine) {
        return totalPrice + parseFloat(cartLine.Product.Price * cartLine.Quantity);
    }, 0);
    cart.Total = totalPrice;
    cart.Message = "Your product Chef " + data.Name + " was succesfuly added to the cart";
    localStorage.setItem('cart', JSON.stringify(cart));
    return cart;
}

function getCart(data = null) {
    if (data == null || data.Id == 0) {
        let cart = { CartLines: [], Total: 0 }
        let storageCart = localStorage.getItem("cart");
        if (storageCart == null) {
            return cart;
        } else {
            cart = JSON.parse(storageCart);
            return cart;
        }
    } else {
        return setCart(data)
    }
}

module.exports = getCart;