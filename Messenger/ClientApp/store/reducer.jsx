import * as actionTypes from './actions';

const initialState = {
    messages: []
};

const reducer = (state = initialState, action) => {
    switch (action.type) {
        case actionTypes.SEND_MESSAGE:
            const message = {
                Id: action.MessageData.Id,
                Recipients: action.MessageData.Recipients,
                Subject: action.MessageData.Subject,
                Body: action.MessageData.Body
            };

            return {
                messages: state.messages.concat(message)
            };
    }
    return state;
};

export default reducer;