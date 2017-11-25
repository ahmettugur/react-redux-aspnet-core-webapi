import { createStore, applyMiddleware } from 'redux';
import promise from 'redux-promise-middleware';
import reducers from '../reducers';

export default createStore(
    reducers,
    applyMiddleware(
        promise()
    )
);