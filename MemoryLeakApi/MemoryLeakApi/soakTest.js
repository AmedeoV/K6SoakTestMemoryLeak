import http from 'k6/http';
import { check, sleep } from 'k6';


export const options = {
    stages: [
        { duration: '30s', target: 10 },
        { duration: '5s', target: 10 },
        { duration: '1s', target: 1 },
    ],
};
export default function () {

    const res = http.get('http://localhost/api/MemoryLeak/memleak/20000');

    check(res, { 'status was 200': (r) => r.status === 200 });
    sleep(1);
}