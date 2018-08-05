import React, { Component } from 'react';
import Message from '../components/message';

class MessagesList extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div className="row">
                <div className="col-md-6">
                    <table className="table table-bordered table-hover">
                        <tbody>
                            <tr>
                                <th>
                                    Id
                                </th>
                                <th>
                                    Recipients
                                </th>
                                <th>
                                    Subject
                                </th>
                                <th>
                                    Body
                                </th>
                            </tr>
                            {this.props.messages.map(message => (
                                <Message key={message.Id} id={message.Id} recipients={message.Recipients} subject={message.Subject} body={message.Body} />
                            ))}
                        </tbody>
                    </table>
                </div>
            </div>
        )
    }
}


export default MessagesList;