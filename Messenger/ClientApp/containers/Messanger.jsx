import React, { Component } from 'react';
import { connect } from 'react-redux';

import MessagesList from '../components/messagesList';
import SendMessage from '../components/sendMessage';
import * as actionTypes from '../store/actions';

class Messanger extends Component {

    render() {
        return (
            <div>
                <SendMessage sendMessages={this.props.onSendMessages} />
                <MessagesList messages={this.props.messages} />
            </div>
        );
    }
}

const mapStateToProps = state => {
    return {
        messages: state.messages
    };
};

const mapDispatchToProps = dispatch => {
    return {
        onSendMessages: (id, recipients, subject, body) => dispatch(
            {
                type: actionTypes.SEND_MESSAGE,
                MessageData:
                    {
                        Id: id,
                        Recipients: recipients,
                        Subject: subject,
                        Body: body
                    }
            }),
    }
};

export default connect(mapStateToProps, mapDispatchToProps)(Messanger);