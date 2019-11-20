import * as actionTypes from './actions';
const initialState = {
    messages: []
};
const reducer = (state = initialState, action) => {
    switch (action.type) {

        case actionTypes.SEND_MESSAGE:

            const message = {
                Subject: action.MessageData.Subject,
                Recipients: action.MessageData.Recipients,
                Body: action.MessageData.Body,
                Id: action.MessageData.Id,
            };

            return {
                
                messages: state.messages.concat(message)

            };
    }
    return state;
};
export default reducer;