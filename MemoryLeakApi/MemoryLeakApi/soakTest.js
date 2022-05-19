import http from 'k6/http';
import { check, sleep } from 'k6';


export const options = {
    stages: [
        // { duration: '20s', target: 10000 },
        { duration: '3m', target: 200 },
        { duration: '2m', target: 100 },
        { duration: '1m', target: 10 },
        { duration: '1s', target: 1 },
    ],
};
export default function (data) {

    const res = http.get('http://localhost/api/MemoryLeak/memleak/20000');

    check(res, { 'status was 200': (r) => r.status === 200 });
    sleep(1);
}