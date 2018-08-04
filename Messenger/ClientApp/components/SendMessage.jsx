import React, { Component } from 'react';
import axios from 'axios';

class SendMessage extends Component {

    constructor(props) {
        super(props);
        this.state = {
            recipients: '',
            subject: '',
            body: ''
        };

        this.recipientsChangedHandler = this.recipientsChangedHandler.bind(this);
        this.subjectChangedHandler = this.subjectChangedHandler.bind(this);
        this.bodyChangedHandler = this.bodyChangedHandler.bind(this);
    }

    recipientsChangedHandler(event) {
        this.setState({ recipients: event.target.value });
    }

    subjectChangedHandler(event) {
        this.setState({ subject: event.target.value });
    }

    bodyChangedHandler(event) {
        this.setState({ body: event.target.value });
    }

    render() {
        return (
            <div className="form-horizontal">
                <div className="form-group">
                    <label className="col-md-2 control-label">Recipients</label>
                    <div className="col-md-4">
                        <input type="text" placeholder="Recipients" onChange={this.recipientsChangedHandler} value={this.state.recipients} className="form-control" />
                    </div>
                </div>
            <div className="form-group">
                    <label className="col-md-2 control-label">Subject</label>
                    <div className="col-md-4">
                        <input type="text" placeholder="Subject" onChange={this.subjectChangedHandler} value={this.state.subject} className="form-control" />
                    </div>
                </div>
                <div className="form-group">
                    <label className="col-md-2 control-label">Body</label>
                    <div className="col-md-4">
                        <textarea type="text" placeholder="Body" onChange={this.bodyChangedHandler} value={this.state.body} className="form-control" />
                    </div>
                </div>
                <div className="form-group">
                    <div className="col-md-offset-2 col-md-10">
                        <button className="btn btn-default" onClick={() => {
                            const message = {
                                Recipients: this.state.recipients.split(";"),
                                Subject: this.state.subject,
                                Body: this.state.body
                            }
                            axios.post("http://localhost:64405/api/Message", message).then(response => {
                                this.props.sendMessages(response.data, this.state.recipients, this.state.subject, this.state.body)
                            })
                        }}>
                            Send
                        </button>
                    </div>
                </div>
            </div>
        );
    }
}

export default SendMessage;