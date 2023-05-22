import http from 'k6/http';
import {check, sleep, fail } from 'k6';

export let options = {
    maxRedirects: 4,
    scenarios: {
        single_user: {
            // name of the executor to use
            executor: 'constant-vus',

            // common scenario configuration
            startTime: '0s',
            duration: '4m50s',
            gracefulStop: '10s',

            // executor-specific configuration
            vus: 1,
        },
        five_user: {
            // name of the executor to use
            executor: 'constant-vus',

            // common scenario configuration
            startTime: '5m',
            duration: '4m50s',
            gracefulStop: '10s',

            // executor-specific configuration
            vus: 5,
        },
        ten_user: {
            // name of the executor to use
            executor: 'shared-iterations',

            // common scenario configuration
            startTime: '10m',
            gracefulStop: '5s',
            maxDuration: '5m',

            // executor-specific configuration
            vus: 10,
            iterations: 200
        }
    }
};

const hostUrl = "https://azure-sorting-api-spring-2023.azurewebsites.net";
const headers = {
    "accept": "application/json",
    "Content-Type": "application/json"
}
const payload = "[\r\n    1765,\r\n    6864,\r\n    5898,\r\n    5750,\r\n    8916,\r\n    3421,\r\n    2416,\r\n    1417,\r\n    9301,\r\n    5196,\r\n    6124,\r\n    4497,\r\n    315,\r\n    6111,\r\n    762,\r\n    3181,\r\n    4424,\r\n    5936,\r\n    8096,\r\n    1000,\r\n    1263,\r\n    9211,\r\n    8937,\r\n    8350,\r\n    8472,\r\n    6754,\r\n    148,\r\n    4840,\r\n    1570,\r\n    3856,\r\n    2116,\r\n    8449,\r\n    7255,\r\n    1869,\r\n    7909,\r\n    8960,\r\n    6378,\r\n    2760,\r\n    4881,\r\n    9972,\r\n    2568,\r\n    9469,\r\n    1836,\r\n    5885,\r\n    9960,\r\n    8381,\r\n    26,\r\n    7713,\r\n    8835,\r\n    4086,\r\n    4254,\r\n    4284,\r\n    1079,\r\n    765,\r\n    1111,\r\n    3487,\r\n    8356,\r\n    8964,\r\n    5015,\r\n    1563,\r\n    4615,\r\n    1331,\r\n    9117,\r\n    7132,\r\n    1134,\r\n    5963,\r\n    7363,\r\n    640,\r\n    6710,\r\n    1400,\r\n    6060,\r\n    9221,\r\n    7758,\r\n    3040,\r\n    8129,\r\n    1569,\r\n    3140,\r\n    6757,\r\n    906,\r\n    7389,\r\n    6324,\r\n    1839,\r\n    8832,\r\n    1176,\r\n    3145,\r\n    2035,\r\n    5643,\r\n    699,\r\n    6860,\r\n    434,\r\n    6811,\r\n    6376,\r\n    3454,\r\n    1202,\r\n    1864,\r\n    8946,\r\n    9248,\r\n    8765,\r\n    7972,\r\n    9325,\r\n    9710,\r\n    2952,\r\n    707,\r\n    6329,\r\n    3097,\r\n    6801,\r\n    5255,\r\n    5089,\r\n    5046,\r\n    2277,\r\n    1507,\r\n    1396,\r\n    566,\r\n    7973,\r\n    9440,\r\n    4968,\r\n    8017,\r\n    2023,\r\n    7014,\r\n    7678,\r\n    5596,\r\n    2919,\r\n    1362,\r\n    1166,\r\n    4634,\r\n    702,\r\n    5525,\r\n    1924,\r\n    5547,\r\n    1070,\r\n    7167,\r\n    950,\r\n    1710,\r\n    5369,\r\n    2776,\r\n    9359,\r\n    3686,\r\n    128,\r\n    689,\r\n    979,\r\n    1255,\r\n    832,\r\n    8961,\r\n    7866,\r\n    3542,\r\n    5965,\r\n    9565,\r\n    4947,\r\n    8137,\r\n    9000,\r\n    8714,\r\n    5517,\r\n    8568,\r\n    7989,\r\n    4178,\r\n    230,\r\n    5753,\r\n    4654,\r\n    4415,\r\n    8366,\r\n    3110,\r\n    7514,\r\n    1034,\r\n    1677,\r\n    6914,\r\n    6423,\r\n    5668,\r\n    7910,\r\n    3154,\r\n    9171,\r\n    4680,\r\n    3221,\r\n    9691,\r\n    4266,\r\n    299,\r\n    142,\r\n    7815,\r\n    7902,\r\n    4750,\r\n    476,\r\n    429,\r\n    7235,\r\n    4739,\r\n    601,\r\n    5068,\r\n    6570,\r\n    7262,\r\n    9972,\r\n    8676,\r\n    7825,\r\n    4121,\r\n    2346,\r\n    7677,\r\n    1740,\r\n    1744,\r\n    3213,\r\n    1237,\r\n    1685,\r\n    4972,\r\n    6247,\r\n    7809,\r\n    7645,\r\n    8310,\r\n    6192,\r\n    5090,\r\n    3982,\r\n    5817,\r\n    5533,\r\n    1303,\r\n    900,\r\n    1275,\r\n    7563,\r\n    1384,\r\n    6219,\r\n    3582,\r\n    8988,\r\n    5082,\r\n    989,\r\n    8416,\r\n    1101,\r\n    5248,\r\n    9780,\r\n    6116,\r\n    9725,\r\n    3666,\r\n    4067,\r\n    7483,\r\n    633,\r\n    8641,\r\n    5000,\r\n    3711,\r\n    8941,\r\n    3288,\r\n    121,\r\n    4053,\r\n    8105,\r\n    5959,\r\n    7045,\r\n    4947,\r\n    6579,\r\n    4558,\r\n    6021,\r\n    7340,\r\n    7934,\r\n    4647,\r\n     9247,\r\n    9438,\r\n    6458,\r\n    6628,\r\n    9384,\r\n    8020\r\n]"


export default function () {
    const params = {headers: headers};
    const result = http.post(`${hostUrl}/api/sort-on1`, payload, params);

    sleep(1);

    const checkResult = check(result, {'status is 200': (r) => r.status === 200,});

    if (!checkResult) {
        fail('request was not successful');
    }
}
