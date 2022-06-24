### 選擇排序法
2種方式
將最大值放首位
將最大值放末位

取出最大(最小)值，放置首位(末位)
以放位的值，不再加入比較

### 選擇排序法分析
無論最好最壞情況，都要找尋極端值(最大或最小)。
比較次數為 : n(n-1)/2
時間複雜度 : O(n2)
為不穩定排序法 : 資料排序有可能會改變。
只需要一個額外空間 : 時間複雜度佳
適用於 : 資料量小，或部分資料已有序狀態。

```
let da = [6,1,5,7,8,2,9,3,4];

let t = da.length;
for(i=0 ; i < t ; i++){
    let smallest = da[i];
    let index = i;
    let flag = 0;
    for(j=i+1 ; j < t ; j++){
        if(smallest < da[j]){
            smallest = da[j];
            index = j;
            flag++
        }
    }
    let temp = da[i];
    da[i] = da[index];
    da[index] = temp;
    if(flag == 0) break;
    console.log('次數:'+(i+1),da);
}
```