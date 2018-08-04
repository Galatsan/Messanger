import React from 'react';


const Message = (props) => (
    <div className="row">
        <div className="col-md-3">
            <h4>Id</h4>
            <p>{props.id}</p>
        </div>
        <div className="col-md-3">
            <h4>Recipients</h4>
            <p>{props.recipients}</p>
        </div>
        <div className="col-md-3">
            <h4>Subject</h4>
            <p>{props.subject}</p>
        </div>
        <div className="col-md-3">
            <h4>Body</h4>
            <p>{props.body}</p>
        </div>
    </div>
);

export default Message;