import React, { useState, useEffect } from "react";
import "./App.scss";
import { ducks } from "./demo";
import DuckItem from "./Duckitem";
import axios from "axios";
import Button from "react-bootstrap/Button";
import ListGroup from "react-bootstrap/ListGroup";
import * as Icon from "react-bootstrap-icons";

function App() {
  const [activities, setActivties] = useState<any>([]);

  useEffect(() => {
    axios.get("http://localhost:5000/api/activities").then((response) => {
      console.log(response);
      if (response.status === 200) {
        setActivties(response.data);
      } else {
        throw new Error(response.status.toString());
      }
    });
  }, []);

  return (
    <div className="App">
      <header className="App-header">
        <Icon.PeopleFill></Icon.PeopleFill>
        <Button variant="primary">Primary</Button>
        <ListGroup>
          {activities.map((activity: any) => {
            return (
              <ListGroup.Item key={activity.id}>
                {activity.title}
              </ListGroup.Item>
            );
          })}
        </ListGroup>
      </header>
    </div>
  );
}

export default App;
