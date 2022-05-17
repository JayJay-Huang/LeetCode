Q : 
皇后棋 可以對其他棋子 直、橫、對角 吃。

提示:
backtracking 演算法
回溯上一動作資料。

(未完??)
```
const { value } = require("jsonpath");

queen = [];
num = 0; // 計算解答組數

function printTable(){
    let x = y = 0;
    num += 1;
    process.stdout.write('\n');
    process.stdout.write('第'+ num +'解答'+'\n\t');
    for(x=0 ; x < 8 ; x++){
        for(y=0 ; y < 8 ; y++){
            if(x == queen[y]){
                process.stdout.write('<Q>');
            } else {
                process.stdout.write('<->');
            }
        }
        process.stdout.write('\n\t');
    }
}

function attack(row,col){
    let i = 0;
    atk = false;
    offset_row = offset_col = 0;
    while((atk != 1)&&(i < col)){
        offset_col = Math.abs(i-col);
        offset_row = Math.abs(queen[i]-row);
        if(queen[i] == row || offset_row == offset_col){
            act = true;
        }
        i = i+1;
    }
    return atk;
}

function decidePosition(){
    let i = 0;
    while(i < 8){
        if(attack(i,value) != 1){
            queen[value] = i;
            if(value == 7){
                printTable();
            } else {
                decidePosition(value + 1);
            }
            i++;
        }
    }
}

// 主程式
decidePosition();

```

