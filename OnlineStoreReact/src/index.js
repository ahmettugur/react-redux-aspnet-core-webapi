import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
// import { createStore, applyMiddleware } from 'redux';
import { BrowserRouter, Route } from 'react-router-dom'

import App from './components/app';
import AdminApp from './components/admin-app';
import LoginForm from "./components/login_form";
// import reducers from './reducers';
// import promise from "redux-promise";
import store from './store';
import registerServiceWorker from './registerServiceWorker';

// export const createStoreWithMiddleware = applyMiddleware(promise)(createStore);

ReactDOM.render(
  <Provider store={store}>
    <BrowserRouter>
      <div>
        <Route path="/web" component={App} />
        <Route path="/admin" component={AdminApp} />
        <Route path="/login" component={LoginForm} />
      </div>
    </BrowserRouter>
  </Provider>
  , document.getElementById('container'));
registerServiceWorker();


/*
const BasicExample = () => (
  <Router>
        <div>
          <ul>
            <li><Link to="/">Home</Link></li>
            <li><Link to="/about">About</Link></li>
            <li><Link to="/topics">Topics</Link></li>
          </ul>

          <hr />
          <Route>
            <Route exact path="/" component={Home} />
            <Route path="/about" component={About} />
            <Route path="/topics" component={Topics} />
          </Route>
        </div>
      </Router>
      )*/