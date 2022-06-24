### 插入排序
將陣列中資料
逐一與已經排序之資料比較
並將結果插入
重複此步驟，直至排序完成。



### 分析
需要 n(n-1)/2 次
時間複雜度 : O(n)
屬於是穩定排序
只需要一個額外空間，所以空間複雜度佳
插入排序會造成大量資料位移，建議使用 linked list 實作。

```
let da = [6,1,5,7,8,2,9,3,4];
let t = da.length;
for(i=0 ; i < t ; i++){
    let temp = da[i];
    let no = i-1;
    while(no >= 0 && temp < da[no]){
        da[no+1] = da[no];
        no--;
    }
    da[no+1] = temp;
    console.log('次數:'+ (i+1),da);
}
console.log(da);
```


