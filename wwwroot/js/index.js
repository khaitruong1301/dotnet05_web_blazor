console.log('hello cybersoft');
//Nơi định nghĩa các hàm js sẽ được gọi từ blazor


window.showMessage = async function (message) {
    console.log(message);
    document.querySelector('#title').innerText = message;
}

window.fetchDataApiStore = async function () {
    //call api store từ browser người dùng đến trực tiếp api store
    let response = await fetch("https://apistore.cybersoft.edu.vn/api/Product");
    let data = await response.json();
    //Sau khi lấy dữ liệu từ api về đưa về giao diện
    renderTable(data.content);
    console.log(data.content);
}

//CSR: client side rendering
window.renderTable = async function (data) {
    let html = '';
    for(let item of data){
        html += `<tr>
            <td>${item.id}</td>
            <td>${item.name}</td>
            <td><img src="${item.image}" width="50" height="50"/></td>
            <td>${item.price}</td>
        </tr>
        `;
    }
    document.querySelector('#productTable').innerHTML = html;
}


window.tinhTong = function(a, b){
    return a + b;
}