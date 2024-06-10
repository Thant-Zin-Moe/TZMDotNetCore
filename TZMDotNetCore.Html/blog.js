const tblBlog = "blogs";
let blogId = null;
getBlogTable();


// readBlog();
// createBlog();
// updateBlog();
// deleteBlog("0de0ace5-1afd-43ab-b621-941d0f2a191e");

function readBlog() {
    let lst = getBLogs();
    console.log(lst);
}

function editBlog(id) {
    let lst = getBLogs();

    const items = lst.filter(x => x.id === id);
    console.log(items);

    console.log(items.length);

    if (items.length == 0) {
        console.log("No data found.");
        errorMessage("No data found.");
        return;
    }

    let item = items[0];
    blogId = item.id;
    $('#txtTitle').val(item.title);
    $('#txtAuthor').val(item.author);
    $('#txtContent').val(item.content);
    $('#txtTitle').focus();
    // return items[0];
}

function createBlog(title, author, content) {
    let lst = getBLogs();

    const requestModel = {
        id: uuidv4(),
        title: title,
        author: author,
        content: content
    };

    lst.push(requestModel);

    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);
    successMessage("Saving Successful.");
    clearControls();
}

function updateBlog(id, title, author, content) {
    let lst = getBLogs();

    const items = lst.filter(x => x.id === id);
    console.log(items);

    console.log(items.length);

    if (items.length == 0) {
        console.log("No data found.");
        errorMessage("No data found.");
        return;
    }

    const item = items[0];
    item.title = title;
    item.author = author;
    item.content = content;

    const index = lst.findIndex(x => x.id === id);
    lst[index] = item;

    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);

    successMessage("Updating Successful.");
}

function deleteBlog(id) {
    let result = confirm("Are you sure want to delete?");
    if (!result) return;

    let lst = getBLogs();

    const items = lst.filter(x => x.id === id);
    if (items.length == 0) {
        console.log("No data found.");
        return;
    }
    lst = lst.filter(x => x.id !== id);
    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);

    successMessage("Deleting Successful.");
    getBlogTable();
}

function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
        (+c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> +c / 4).toString(16)
    );
}

function getBLogs() {
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);
    let lst = [];
    if (blogs !== null) {
        lst = JSON.parse(blogs);
    }
    return lst;
}
$('#btnSave').click(function () {
    const title = $('#txtTitle').val();
    const author = $('#txtAuthor').val();
    const content = $('#txtContent').val();

    if (blogId == null) {
        createBlog(title, author, content);
    }
    else {
        updateBlog(blogId, title, author, content);
        blogId = null;
    }

    getBlogTable();
})

function successMessage(message) {
    alert(message);
}

function errorMessage(message) {
    alert(message);
}

function clearControls() {
    $('#txtTitle').val('');
    $('#txtAuthor').val('');
    $('#txtContent').val('');
    $('#txtTitle').focus();
}

function getBlogTable() {
    const lst = getBLogs();
    let count = 0;
    let htmlBows = '';
    lst.forEach(item => {
        const htmlRow = `
        <tr>
            <td>
                <button type="button" class="btn btn-warning" onclick="editBlog('${item.id}')" >Edit</button>
                <button type="button" class="btn btn-danger" onclick="deleteBlog('${item.id}')" >Delete</button>
            </td>
            <td>${++count}</td>
            <td>${item.title}</td>
            <td>${item.author}</td>
            <td>${item.content}</td>
        </tr>`;
        htmlBows += htmlRow;
    });

    $('#tbody').html(htmlBows);
}