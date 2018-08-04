import axios from 'axios';

const instance = axios.create({
    baseURL: 'http://localhost:64405/'
});

export default instance;