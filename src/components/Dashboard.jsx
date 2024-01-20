import React from "react";
import Headers from "./Headers";
const Dashboard = () => {
  return (
    <>
     <Headers />
      <div>Welcome {localStorage.getItem("logedInUserEmail")}</div>
    </>
   
  );
};

export default Dashboard;
