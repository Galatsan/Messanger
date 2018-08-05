import React, { Component } from 'react';
import saveMessage from "../services/messangerService"

class SendMessage extends Component {

    constructor(props) {
        super(props);
        this.state = {
            recipients: '',
            subject: '',
            body: '',
            recipientsValid: false,
            subjectValid: false,
            bodyValid: false,
            disableForm: false
        };
        this.recipientsChangedHandler = this.recipientsChangedHandler.bind(this);
        this.subjectChangedHandler = this.subjectChangedHandler.bind(this);
        this.bodyChangedHandler = this.bodyChangedHandler.bind(this);
        this.sendMessage = this.sendMessage.bind(this);
    }

    recipientsChangedHandler(event) {
        var recipients = event.target.value;
        var isValid = this.validateRecipients(recipients);
        this.setState(
            {
                recipients: recipients,
                recipientsValid: isValid
            });
    }

    subjectChangedHandler(event) {
        var subject = event.target.value;
        var isValid = this.validateSubject(subject);
        this.setState(
            {
                subject: subject,
                subjectValid: isValid
            });
    }

    bodyChangedHandler(event) {
        var body = event.target.value;
        var isValid = this.validateSubject(body);
        this.setState(
            {
                body: body,
                bodyValid: isValid
            });
    }

    validateRecipients(recipients) {
        return recipients.length > 0;
    }

    validateSubject(subject) {
        return subject.length > 0;
    }

    validateBody(body) {
        return body.length > 0;
    }

    sendMessage(event) {
        e.preventDefault();
        if (this.state.recipientsValid && this.state.subjectValid && this.state.bodyValid) {
            this.setState({ disableForm: true });
            const message = {
                Recipients: this.state.recipients.split(";"),
                Subject: this.state.subject,
                Body: this.state.body
            }
            saveMessage(message).then(response => {
                let id = response.data
                this.props.sendMessages(id, this.state.recipients, this.state.subject, this.state.body);
                this.setState(
                    {
                        recipients: '',
                        subject: '',
                        body: '',
                        recipientsValid: false,
                        subjectValid: false,
                        bodyValid: false,
                        disableForm: false
                    });
            })
        }
    }

    render() {
        let recipientsColor = this.state.recipientsValid === true ? "green" : "red";
        let subjectColor = this.state.subjectValid === true ? "green" : "red";
        let bodyColor = this.state.bodyValid === true ? "green" : "red";
        return (
            <div>
                <h2>Messanger</h2>
                <form onSubmit={this.sendMessage}>
                    <div className="form-horizontal">
                        <div className="form-group">
                            <label className="col-md-2 control-label">Recipients</label>
                            <div className="col-md-4">
                                <input type="text" disabled={(this.state.disableForm) ? "disabled" : ""} style={{ borderColor: recipientsColor }} placeholder="Recipients" onChange={this.recipientsChangedHandler} value={this.state.recipients} className="form-control" />
                            </div>
                        </div>
                        <div className="form-group">
                            <label className="col-md-2 control-label">Subject</label>
                            <div className="col-md-4">
                                <input type="text" disabled={(this.state.disableForm) ? "disabled" : ""} style={{ borderColor: subjectColor }} placeholder="Subject" onChange={this.subjectChangedHandler} value={this.state.subject} className="form-control" />
                            </div>
                        </div>
                        <div className="form-group">
                            <label className="col-md-2 control-label">Body</label>
                            <div className="col-md-4">
                                <textarea type="text" disabled={(this.state.disableForm) ? "disabled" : ""} style={{ borderColor: bodyColor }} placeholder="Body" onChange={this.bodyChangedHandler} value={this.state.body} className="form-control" />
                            </div>
                        </div>
                        <div className="form-group">
                            <div className="col-md-offset-2 col-md-10">
                                <input className="btn btn-default" type="submit" value="Send" disabled={(this.state.disableForm) ? "disabled" : ""} />
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        );
    }
}

export default SendMessage;