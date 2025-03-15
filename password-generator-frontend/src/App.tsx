import { useEffect, useState } from "react";
import "./App.css";

// Updated type to match the JSON response
type PasswordResponse = {
  password: string;
};

function App() {
  const [password, setPassword] = useState<string | null>(null);
  const [isLoading, setIsLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  const fetchPassword = (): void => {
    setIsLoading(true);
    setError(null);

    fetch("http://localhost:5177/api/password/RandomPassword/")
      .then((response: Response) => {
        if (!response.ok) {
          throw new Error("Failed to fetch password");
        }
        return response.json();
      })
      .then((json: PasswordResponse) => {
        setPassword(json.password);
        setIsLoading(false);
      })
      .catch((err: Error) => {
        setError(err.message);
        setIsLoading(false);
      });
  };

  useEffect(() => {
    fetchPassword();
  }, []);

  return (
    <div className="App">
      <table className="navbar">
        <tbody>
          <tr>
            <td>
              <h1>Password Generator</h1>
            </td>
          </tr>
        </tbody>
      </table>

      <div className="content">
        <button onClick={fetchPassword} disabled={isLoading}>
          {isLoading ? "Generating..." : "Generate New Password"}
        </button>

        {error && <p className="error">{error}</p>}

        {password && (
          <div className="password-display">
            <h2>Your Password:</h2>
            <div className="password-box">{password}</div>
          </div>
        )}
      </div>
    </div>
  );
}

export default App;
