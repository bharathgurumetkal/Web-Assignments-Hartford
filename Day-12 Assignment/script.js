// Local Data (Mock API)
const policiesData = [ 
 { id: 1, name: "Health Plus", type: "Health", premium: 12000, duration: 1, status: "Active" }, 
 { id: 2, name: "Life Secure", type: "Life", premium: 9000, duration: 10, status: "Inactive" }, 
 { id: 3, name: "Car Protect", type: "Vehicle", premium: 7000, duration: 1, status: "Active" }, 
 { id: 4, name: "Family Health", type: "Health", premium: 15000, duration: 2, status: "Active" } 
];

let policies = [];

// Simulated Fetch API
async function fetchPoliciesFromAPI() {
  try {
    // Simulate API delay
    await new Promise(resolve => setTimeout(resolve, 1000));

    // Simulate API success
    return policiesData;

  } catch (error) {
    throw new Error("API Fetch Failed");
  }
}

// Load Policies
async function loadPolicies() {
  try {
    policies = await fetchPoliciesFromAPI();
    displayPolicies(policies);
    calculateTotalPremium();
  } catch (error) {
    alert(error.message);
  }
}

//Task:2 Display Policies
function displayPolicies(policyList) {
  const container = document.getElementById("policiesContainer");
  container.innerHTML = "";

  policyList.forEach(policy => {
    const div = document.createElement("div");
    div.className = "policy";
    div.innerHTML = `
      <b>${policy.name}</b><br>
      id:${policy.id}<br>
      Type: ${policy.type}<br>
      Premium: ₹${policy.premium}<br>
      Duration: ${policy.duration} year(s)<br>
      Status: ${policy.status}
    `;
    container.appendChild(div);
  });
}

//// Task 3: Filter Policies
function filterPolicies(type) {
  const filtered = policies.filter(p => p.type === type);
  displayPolicies(filtered);
}

function showAll() {
  displayPolicies(policies);
}


// Task 4: Calculate Total Premium (Reduce)
function calculateTotalPremium() {
    try{ 
  const total = policies
    .filter(p => p.status === "Active")
    .reduce((sum, p) => sum + p.premium, 0);

  document.getElementById("totalPremium").innerText = total;
    }catch(err){
        alert(err.message);
    }
}

// Task 5: Apply Discount (Map)
function applyDiscount() {
  policies = policies.map(p => {
    if (p.premium > 10000) {
      return { ...p, premium: p.premium * 0.9 }; // 10% discount
    }
    return p;
  });

  displayPolicies(policies);
  calculateTotalPremium();
}

// Task 6: Policy Approval Simulation (Callback)
function approvePolicy(policyId, callback) {
  setTimeout(() => {
    const policy = policies.find(p => p.id === policyId);

    if (!policy) {
      callback("Invalid Policy ID", null);
    } else {
      policy.status = "Active";
      callback(null, policy);
    }
  }, 2000);
}

// Task 7: Promise-based Approval
function approvePolicyPromise(policyId) {
  return new Promise((resolve, reject) => {
    approvePolicy(policyId, (error, result) => {
      if (error) reject(error);
      else resolve(result);
    });
  });
}

function handlePurchase(){
    const id=Number(document.getElementById("policyId").value);
    if(!id||id===0){
        alert("Please enter a Policy ID");
        return;
    }
    approvePolicyPromise(id)
    displayPolicies(policies);
    calculateTotalPremium();
}

//Task 8:Error Handling(it is already implemented in above functions)
//Invalid PolicyID
//approvePolicy(99);