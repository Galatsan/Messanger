import React, { Component } from 'react';
import { connect } from 'react-redux';

import Message from '../components/Message';
import SendMessage from '../components/SendMessage';
import * as actionTypes from '../store/actions';

class Messanger extends Component {

    render() {
        return (
            <div>
                <SendMessage sendMessages={this.props.onSendMessages} />
                {this.props.messages.map(message => (
                    <Message
                        id={message.Id}
                        recipients={message.Recipients}
                        subject={message.Subject}
                        body={message.Body} />
                ))}
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