const API = "https://dummyjson.com/products";

// ---------------- GET ALL ----------------
async function getAllProducts() {
  const res = await fetch(API);
  const data = await res.json();
  renderTable(data.products);
}

// ---------------- GET SINGLE ----------------
async function getSingleProduct() {
  const id = document.getElementById("pid").value;
  if (!id) return alert("Enter Product ID");

  const res = await fetch(`${API}/${id}`);
  if (res.status !== 200) return alert("Product Not Found");

  const product = await res.json();
  renderTable([product]);
}

// ---------------- CREATE ----------------
async function createProduct() {
  const title = document.getElementById("title").value;
  const price = document.getElementById("price").value;
  const brand = document.getElementById("brand").value;

  if (!title || !price || !brand)
    return alert("Fill all fields");

  const res = await fetch(`${API}/add`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ title, price, brand })
  });

  const data = await res.json();
  alert("Created: " + data.title);
  getAllProducts();
}

// ---------------- UPDATE ----------------
async function updateProduct() {
  const id = document.getElementById("pid").value;
  if (!id) return alert("Enter Product ID");

  const title = document.getElementById("title").value;
  const price = document.getElementById("price").value;
  const brand = document.getElementById("brand").value;

  const body = {};
  if (title) body.title = title;
  if (price) body.price = price;
  if (brand) body.brand = brand;

  const res = await fetch(`${API}/${id}`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(body)
  });

  const data = await res.json();
  alert("Updated: " + data.title);
  getAllProducts();
}

// ---------------- DELETE ----------------
async function deleteProduct() {
  const id = document.getElementById("pid").value;
  if (!id) return alert("Enter Product ID");

  await fetch(`${API}/${id}`, { method: "DELETE" });
  alert("Deleted Product ID: " + id);
  getAllProducts();
}

// ---------------- TABLE RENDER ----------------
function renderTable(products) {
  const table = document.getElementById("productTable");
  table.innerHTML = "";

  products.forEach(p => {
    table.innerHTML += `
      <tr>
        <td>${p.id}</td>
        <td>${p.title}</td>
        <td>₹ ${p.price}</td>
        <td>${p.brand}</td>
      </tr>
    `;
  });
}

// Load initially
getAllProducts();
