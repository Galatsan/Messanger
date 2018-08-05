import React from 'react';


const Message = (props) => (
    <tr>
        <td>
            {props.id}
        </td>
        <td>
            {props.recipients}
        </td>
        <td>
            {props.subject}
        </td>
        <td>
            {props.body}
        </td>
    </tr>
);

export default Message;