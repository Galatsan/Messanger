import axios from 'axios';

const serverUrl = "http://localhost:64405/";
const saveMessage = (message) => {
    return axios.post(serverUrl + "api/Message", message);
};

export default saveMessage;